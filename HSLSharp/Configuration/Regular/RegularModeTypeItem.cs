using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSLSharp.Configuration
{
    public class RegularModeTypeItem
    {
        public RegularModeTypeItem()
        {

        }


        public RegularModeTypeItem(int code,string text,Brush backColor )
        {
            Code = code;
            Text = text;
            BackColor = backColor;
        }


        public int Code { get; set; }

        public string Text { get; set; }

        public Brush BackColor { get; set; }


        public override string ToString( )
        {
            return Text;
        }


        #region Const Resource


        /// <summary>
        /// Bool数据类型
        /// </summary>
        public static readonly RegularModeTypeItem Bool = new RegularModeTypeItem( 1, "bool" ,Brushes.PaleGreen );
        /// <summary>
        /// Byte数据类型
        /// </summary>
        public static readonly RegularModeTypeItem Byte = new RegularModeTypeItem( 2, "byte" ,Brushes.Aquamarine );
        /// <summary>
        /// short数据类型
        /// </summary>
        public static readonly RegularModeTypeItem Int16 = new RegularModeTypeItem( 3, "short" ,Brushes.Pink );
        /// <summary>
        /// ushort数据类型
        /// </summary>
        public static readonly RegularModeTypeItem UInt16 = new RegularModeTypeItem( 4, "ushort" ,Brushes.Gold );
        /// <summary>
        /// int数据类型
        /// </summary>
        public static readonly RegularModeTypeItem Int32 = new RegularModeTypeItem( 5, "int" ,Brushes.BlanchedAlmond );
        /// <summary>
        /// uint数据类型
        /// </summary>
        public static readonly RegularModeTypeItem UInt32 = new RegularModeTypeItem( 6, "uint" ,Brushes.DarkKhaki );
        /// <summary>
        /// long数据类型
        /// </summary>
        public static readonly RegularModeTypeItem Int64 = new RegularModeTypeItem( 7, "long", Brushes.PapayaWhip );
        /// <summary>
        /// ulong数据类型
        /// </summary>
        public static readonly RegularModeTypeItem UInt64 = new RegularModeTypeItem( 8, "ulong", Brushes.Thistle );
        /// <summary>
        /// float数据类型
        /// </summary>
        public static readonly RegularModeTypeItem Float = new RegularModeTypeItem( 9, "float", Brushes.Wheat );
        /// <summary>
        /// double数据类型
        /// </summary>
        public static readonly RegularModeTypeItem Double = new RegularModeTypeItem( 10, "double", Brushes.LightGoldenrodYellow );
        /// <summary>
        /// string数据类型，ASCII编码
        /// </summary>
        public static readonly RegularModeTypeItem StringAscii = new RegularModeTypeItem( 11, "string[ascii]", Brushes.Yellow );
        /// <summary>
        /// string数据类型，Unicode编码
        /// </summary>
        public static readonly RegularModeTypeItem StringUnicode = new RegularModeTypeItem( 12, "string[unicode]", Brushes.YellowGreen );
        /// <summary>
        /// string数据类型，UTF8编码
        /// </summary>
        public static readonly RegularModeTypeItem StringUtf8 = new RegularModeTypeItem( 13, "string[utf8]", Brushes.SandyBrown );


        public static RegularModeTypeItem GetDataPraseItemByCode(int code)
        {
            switch(code)
            {
                case 1:return Bool;
                case 2:return Byte;
                case 3:return Int16;
                case 4:return UInt16;
                case 5:return Int32;
                case 6:return UInt32;
                case 7:return Int64;
                case 8:return UInt64;
                case 9:return Float;
                case 10:return Double;
                case 11:return StringAscii;
                case 12:return StringUnicode;
                case 13:return StringUtf8;
                default:return new RegularModeTypeItem( code, "none", Brushes.Black );
            }
        }

        #endregion
    }
}
