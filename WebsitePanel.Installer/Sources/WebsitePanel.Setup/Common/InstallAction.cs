// Copyright (c) 2011, Outercurve Foundation.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
//
// - Redistributions of source code must  retain  the  above copyright notice, this
//   list of conditions and the following disclaimer.
//
// - Redistributions in binary form  must  reproduce the  above  copyright  notice,
//   this list of conditions  and  the  following  disclaimer in  the documentation
//   and/or other materials provided with the distribution.
//
// - Neither  the  name  of  the  Outercurve Foundation  nor   the   names  of  its
//   contributors may be used to endorse or  promote  products  derived  from  this
//   software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING,  BUT  NOT  LIMITED TO, THE IMPLIED
// WARRANTIES  OF  MERCHANTABILITY   AND  FITNESS  FOR  A  PARTICULAR  PURPOSE  ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR
// ANY DIRECT, INDIRECT, INCIDENTAL,  SPECIAL,  EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO,  PROCUREMENT  OF  SUBSTITUTE  GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)  HOWEVER  CAUSED AND ON
// ANY  THEORY  OF  LIABILITY,  WHETHER  IN  CONTRACT,  STRICT  LIABILITY,  OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE)  ARISING  IN  ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

using System;
using System.Collections.Generic;
using System.Text;

namespace WebsitePanel.Setup
{
	public enum ActionTypes
	{
		None,
		CopyFiles,
		CreateWebSite,
		CryptoKey,
		ServerPassword,
		UpdateServerPassword,
		UpdateConfig,
		UpdateEnterpriseServerUrl,
		CreateDatabase,
		CreateDatabaseUser,
		ExecuteSql,
		DeleteRegistryKey,
		DeleteDirectory,
		DeleteDatabase,
		DeleteDatabaseUser,
		DeleteDatabaseLogin,
		DeleteWebSite,
		DeleteVirtualDirectory,
		DeleteUserAccount,
		DeleteUserMembership,
		DeleteApplicationPool,
		DeleteFiles,
		UpdateWebSite,
		//UpdateFiles,
		Backup,
		BackupDatabase,
		BackupDirectory,
		BackupConfig,
		UpdatePortal2811,
		UpdateEnterpriseServer2810,
		UpdateServer2810,
		CreateShortcuts,
		DeleteShortcuts,
		UpdateServers,
		CopyWebConfig,
		UpdateWebConfigNamespaces,
		StopApplicationPool,
		StartApplicationPool,
		RegisterWindowsService,
		UnregisterWindowsService,
		StartWindowsService,
		StopWindowsService,
		ServiceSettings,
		CreateUserAccount,
		InitSetupVariables,
		UpdateServerAdminPassword,
		UpdateLicenseInformation,
		ConfigureStandaloneServerData,
		CreateWPServerLogin,
		FolderPermissions,
		AddCustomErrorsPage,
		SwitchServer2AspNet40,
		SwitchEntServer2AspNet40,
		SwitchWebPortal2AspNet40,
	}
	
	public class InstallAction
	{
		public InstallAction(ActionTypes type)
		{
			this.ActionType = type;
		}

		public ActionTypes ActionType{ get; set; }
		

		public string Name{ get; set; }
		

		public string Log{ get; set; }
		

		public string Description{ get; set; }
		

		public string ConnectionString{ get; set; }
		

		public string Key{ get; set; }
		

		public string Path{ get; set; }
		

		public string UserName{ get; set; }
		

		public string SiteId{ get; set; }
		

		public string Source{ get; set; }
		

		public string Destination{ get; set; }
		

		public bool Empty{ get; set; }
		

		public string IP{ get; set; }
		

		public string Port{ get; set; }
		

		public string Domain{ get; set; }
		

		public string[] Membership { get; set; }
		
		
		public SetupVariables SetupVariables { get; set; }

		
		public string Url { get; set; }
	
	}
}
