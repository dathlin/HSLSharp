using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSLSharp.Configuration
{
    public class DataParseItem
    {
        public DataParseItem()
        {

        }


        public DataParseItem(int code,string text)
        {
            Code = code;
            Text = text;
        }


        public int Code { get; set; }

        public string Text { get; set; }



        public override string ToString( )
        {
            return Text;
        }


        #region Const Resource


        /// <summary>
        /// Bool数据类型
        /// </summary>
        public static readonly DataParseItem Bool = new DataParseItem( 1, "bool" );
        /// <summary>
        /// Byte数据类型
        /// </summary>
        public static readonly DataParseItem Byte = new DataParseItem( 2, "byte" );
        /// <summary>
        /// short数据类型
        /// </summary>
        public static readonly DataParseItem Int16 = new DataParseItem( 3, "short" );
        /// <summary>
        /// ushort数据类型
        /// </summary>
        public static readonly DataParseItem UInt16 = new DataParseItem( 4, "ushort" );
        /// <summary>
        /// int数据类型
        /// </summary>
        public static readonly DataParseItem Int32 = new DataParseItem( 5, "int" );
        /// <summary>
        /// uint数据类型
        /// </summary>
        public static readonly DataParseItem UInt32 = new DataParseItem( 6, "uint" );
        /// <summary>
        /// long数据类型
        /// </summary>
        public static readonly DataParseItem Int64 = new DataParseItem( 7, "long" );
        /// <summary>
        /// ulong数据类型
        /// </summary>
        public static readonly DataParseItem UInt64 = new DataParseItem( 8, "ulong" );
        /// <summary>
        /// float数据类型
        /// </summary>
        public static readonly DataParseItem Float = new DataParseItem( 9, "float" );
        /// <summary>
        /// double数据类型
        /// </summary>
        public static readonly DataParseItem Double = new DataParseItem( 10, "double" );
        /// <summary>
        /// string数据类型，ASCII编码
        /// </summary>
        public static readonly DataParseItem StringAscii = new DataParseItem( 11, "string[ascii]" );
        /// <summary>
        /// string数据类型，Unicode编码
        /// </summary>
        public static readonly DataParseItem StringUnicode = new DataParseItem( 12, "string[unicode]" );
        /// <summary>
        /// string数据类型，UTF8编码
        /// </summary>
        public static readonly DataParseItem StringUtf8 = new DataParseItem( 13, "string[utf8]" );


        public static DataParseItem GetDataPraseItemByCode(int code)
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
                default:return new DataParseItem( code, "none" );
            }
        }

        #endregion
    }
}
