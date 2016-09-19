using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tools.SMS
{
    public interface ISms
    {
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="msg">要发送的短信</param>
        /// <param name="phone">手机号码</param>
        /// <returns></returns>
        Object SendSms(String msg,List<String> phone);

        /// <summary>
        /// 设置用于发送短信的帐户（网络平台使用）
        /// </summary>
        /// <param name="user">用户名</param>
        /// <param name="userPwd">密码</param>
        void SetUserInfo(String user,String userPwd);

        /// <summary>
        /// 设置参数集
        /// </summary>
        /// <param name="args">参数列表</param>
        void SetParameter(String[] args);

        /// <summary>
        /// 查询帐户剩余条数
        /// </summary>
        /// <param name="user">用户名</param>
        /// <param name="userPwd">密码</param>
        /// <returns>-1 帐户未注册 -2 其它错误 -3密码错误 x 剩余条数</returns>
        int SearchSmsCount(String user, String userPwd);

        /// <summary>
        /// 查询默认帐户剩余条数
        /// </summary>
        /// <returns>-1 帐户未注册 -2 其它错误 -3密码错误 x 剩余条数</returns>
        int SearchSmsCount();
    }
}
