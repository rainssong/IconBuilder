using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

//原作：wangqiuyun http://my.csdn.net/wangqiuyun
//更新：rainssong http://blog.sina.com.cn/rainssong
namespace IconBuilder
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
