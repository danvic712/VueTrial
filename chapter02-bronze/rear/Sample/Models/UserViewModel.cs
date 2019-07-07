//-----------------------------------------------------------------------
// <copyright file= "UserViewModel.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/7/6 18:08:46
// Modified by:
// Description: 用户视图模型
//-----------------------------------------------------------------------

namespace Sample.Models
{
    public class UserViewModel
    {
        #region Attributes

        /// <summary>
        /// 用户编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public string CreatedTime { get; set; }

        #endregion Attributes
    }
}