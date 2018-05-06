using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HSLSharp.Device;
using HslCommunication.Core;

namespace HSLSharp.Controls
{
    public partial class MonitorControl : UserControl
    {
        public MonitorControl( )
        {
            InitializeComponent( );
            DoubleBuffered = true;
            hybirdLock = new HslCommunication.Core.SimpleHybirdLock( );
        }

        private void MonitorControl_Load( object sender, EventArgs e )
        {
            timerRefresh = new Timer( );
            timerRefresh.Interval = 1000;
            timerRefresh.Tick += TimerRefresh_Tick;
            timerRefresh.Start( );
        }

        private void MonitorControl_Paint( object sender, PaintEventArgs e )
        {
            if (lists != null)
            {

                int offline = 0;
                long requestSuccessTotle = 0;
                long requestFailedTotle = 0;

                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                hybirdLock.Enter( );
                // 每个格子大小为10*10 间隙2
                Point point = new Point( 1, 1 );
                for (int i = 0; i < lists.Count; i++)
                {
                    Rectangle rectangle = new Rectangle( point.X, point.Y, 12, 12 );
                    lists[i].PaintRegion = rectangle;
                    requestSuccessTotle += lists[i].RequestSuccessCount;
                    requestFailedTotle += lists[i].RequestFailedCount;

                    if (lists[i].IsError)
                    {
                        offline++;                 // 统计离线设备
                        e.Graphics.FillRectangle( Brushes.Pink, rectangle );
                        if (ActiveTick == 1) e.Graphics.DrawRectangle( Pens.Red, rectangle );
                    }
                    else
                    {
                        int second = (int)((DateTime.Now - lists[i].ActiveTime).TotalSeconds);
                        if (second < 10)
                        {
                            e.Graphics.FillRectangle( Brushes.Green, rectangle );
                        }
                        else if (second < 30)
                        {
                            e.Graphics.FillRectangle( Brushes.LimeGreen, rectangle );
                        }
                        else if (second < 60)
                        {
                            e.Graphics.FillRectangle( Brushes.PaleGreen, rectangle );
                        }
                        else
                        {
                            e.Graphics.FillRectangle( Brushes.WhiteSmoke, rectangle );
                            e.Graphics.DrawRectangle( Pens.Gray, rectangle );
                        }
                    }

                    if (point.X + 14 < Width - 13)
                    {
                        point.X += 14;
                    }
                    else
                    {
                        point.X = 1;
                        point.Y += 14;
                    }
                }

                if (ActiveIndex >= 0 && ActiveIndex < lists.Count)
                {
                    Rectangle rectangle = new Rectangle( 1, Height - Font.Height - 1, Width - 1, Font.Height );
                    e.Graphics.FillRectangle( Brushes.Lavender, rectangle );
                    rectangle.X = 1;


                    e.Graphics.DrawString( "名称：" + lists[ActiveIndex].Name + " 状态：" + (lists[ActiveIndex].IsError ? "掉线" : "在线") +
                        " 上次接收时间：" + lists[ActiveIndex].ActiveTime.ToString( ), Font, Brushes.Blue, rectangle );
                }
                else
                {
                    e.Graphics.DrawString( "设备总计：" + lists.Count, Font, Brushes.Chocolate, new Point( 1, Height - Font.Height - 1 ) );
                    e.Graphics.DrawString( "离线总计：" + offline, Font, Brushes.Red, new Point( 150, Height - Font.Height - 1 ) );
                    e.Graphics.DrawString( "请求成功：" + requestSuccessTotle, Font, Brushes.Purple, new Point( 300, Height - Font.Height - 1 ) );
                    e.Graphics.DrawString( "请求失败：" + requestFailedTotle, Font, Brushes.Tomato, new Point( 500, Height - Font.Height - 1 ) );
                }

                hybirdLock.Leave( );
            }
        }


        #region Private Member

        private List<IDeviceCore> lists = null;                          // 所有的监视对象
        private int ActiveIndex = -1;                                    // 活跃的索引信息
        private Timer timerRefresh = null;                               // 每秒更新界面的定时器 
        private SimpleHybirdLock hybirdLock;                             // 数据同步锁
        private int ActiveTick = 0;

        #endregion

        /// <summary>
        /// 更新数据引用
        /// </summary>
        /// <param name="lists"></param>
        public void UpdateList( List<IDeviceCore> lists )
        {
            this.lists = lists;
            Invalidate( );
        }

        private void MonitorControl_MouseMove( object sender, MouseEventArgs e )
        {
            if (lists != null)
            {
                int result = -1;
                for (int i = 0; i < lists.Count; i++)
                {
                    if (lists[i].PaintRegion.Contains( e.Location ))
                    {
                        result = i;
                        break;
                    }
                }

                ActiveIndex = result;
            }
            else
            {
                ActiveIndex = -1;
            }

            Invalidate( );
        }

        private void MonitorControl_MouseLeave( object sender, EventArgs e )
        {
            ActiveIndex = -1;
            Invalidate( );
        }

        private void TimerRefresh_Tick( object sender, EventArgs e )
        {
            if (ActiveTick == 0) ActiveTick = 1;
            else ActiveTick = 0;

            Invalidate( );
        }

        private void MonitorControl_SizeChanged( object sender, EventArgs e )
        {
            Invalidate( );
        }
    }
}
