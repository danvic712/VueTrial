//-----------------------------------------------------------------------
// <copyright file= "UserModel.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/7/7 9:45:04
// Modified by:
// Description: 用户实体模型
//-----------------------------------------------------------------------
using System;

namespace Sample.Models
{
    public class UserModel
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
        public DateTime CreatedTime { get; set; }

        #endregion Attributes
    }
}