﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using FineUI;
using CykjSoft.UserPermissionManager.Utils;

namespace XASYU.admin
{
    public partial class role_new : PageBase
    {
        #region ViewPower

        /// <summary>
        /// 本页面的浏览权限，空字符串表示本页面不受权限控制
        /// </summary>
        public override string ViewPower
        {
            get
            {
                return "CoreRoleNew";
            }
        }

        #endregion

        #region 初始化变量
        int V_ITOTALCOUNT = -1;
        private XASYU.MODEL.SYS_ROLESModel RoleModel = new MODEL.SYS_ROLESModel();
        private XASYU.MODEL.SYS_ROLEUSERSModel RoleUserModel = new MODEL.SYS_ROLEUSERSModel();
        CykjSoft.Bean.UserBean userBean = new CykjSoft.Bean.UserBean();
        #endregion

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            
            btnClose.OnClientClick = ActiveWindow.GetHideReference();

        }

        #endregion

        #region Events

        private void SaveItem()
        {
            //将Role表中的角色删除
            RoleModel.Name = tbxName.Text.Trim();
            RoleModel.Remark = tbxRemark.Text.Trim();
            RoleModel.OpType = DataOperationType.Add;
            if (XASYU.BLL.DataBaseManager.op_SYS_ROLES(userBean, RoleModel) == 0)
            {
                Alert.Show("添加成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            }
            else
            {
                Alert.Show("添加失败！", String.Empty, ActiveWindow.GetHidePostBackReference());
            }
          
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            SaveItem();

            //Alert.Show("添加成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            //PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        #endregion

    }
}
