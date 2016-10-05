// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using Microsoft.Azure;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Reflection;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    public partial class InvokeAzureComputeMethodCmdlet : ComputeAutomationBaseCmdlet
    {
        protected object CreateSnapshotUpdateDynamicParameters()
        {
            dynamicParameters = new RuntimeDefinedParameterDictionary();
            var pResourceGroupName = new RuntimeDefinedParameter();
            pResourceGroupName.Name = "ResourceGroupName";
            pResourceGroupName.ParameterType = typeof(string);
            pResourceGroupName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 1,
                Mandatory = true
            });
            pResourceGroupName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ResourceGroupName", pResourceGroupName);

            var pSnapshotName = new RuntimeDefinedParameter();
            pSnapshotName.Name = "SnapshotName";
            pSnapshotName.ParameterType = typeof(string);
            pSnapshotName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 2,
                Mandatory = true
            });
            pSnapshotName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("SnapshotName", pSnapshotName);

            var pSnapshot = new RuntimeDefinedParameter();
            pSnapshot.Name = "Snapshot";
            pSnapshot.ParameterType = typeof(Snapshot);
            pSnapshot.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 3,
                Mandatory = true
            });
            pSnapshot.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("Snapshot", pSnapshot);

            var pArgumentList = new RuntimeDefinedParameter();
            pArgumentList.Name = "ArgumentList";
            pArgumentList.ParameterType = typeof(object[]);
            pArgumentList.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByStaticParameters",
                Position = 4,
                Mandatory = true
            });
            pArgumentList.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ArgumentList", pArgumentList);

            return dynamicParameters;
        }

        protected void ExecuteSnapshotUpdateMethod(object[] invokeMethodInputParameters)
        {
            string resourceGroupName = (string)ParseParameter(invokeMethodInputParameters[0]);
            string snapshotName = (string)ParseParameter(invokeMethodInputParameters[1]);
            Snapshot snapshot = (Snapshot)ParseParameter(invokeMethodInputParameters[2]);

            var result = SnapshotsClient.Update(resourceGroupName, snapshotName, snapshot);
            WriteObject(result);
        }
    }

    public partial class NewAzureComputeArgumentListCmdlet : ComputeAutomationBaseCmdlet
    {
        protected PSArgument[] CreateSnapshotUpdateParameters()
        {
            string resourceGroupName = string.Empty;
            string snapshotName = string.Empty;
            Snapshot snapshot = new Snapshot();

            return ConvertFromObjectsToArguments(
                 new string[] { "ResourceGroupName", "SnapshotName", "Snapshot" },
                 new object[] { resourceGroupName, snapshotName, snapshot });
        }
    }

    [Cmdlet("Update", "AzureRmSnapshot", DefaultParameterSetName = "InvokeByDynamicParameters", SupportsShouldProcess = true)]
    public partial class UpdateAzureRmSnapshot : InvokeAzureComputeMethodCmdlet
    {
        public override string MethodName { get; set; }

        protected override void ProcessRecord()
        {
            this.MethodName = "SnapshotUpdate";
            if (ShouldProcess(this.dynamicParameters["ResourceGroupName"].Value.ToString(), VerbsData.Update))
            {
                base.ProcessRecord();
            }
        }

        public override object GetDynamicParameters()
        {
            dynamicParameters = new RuntimeDefinedParameterDictionary();
            var pResourceGroupName = new RuntimeDefinedParameter();
            pResourceGroupName.Name = "ResourceGroupName";
            pResourceGroupName.ParameterType = typeof(string);
            pResourceGroupName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 1,
                Mandatory = true,
                ValueFromPipeline = false
            });
            pResourceGroupName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ResourceGroupName", pResourceGroupName);

            var pSnapshotName = new RuntimeDefinedParameter();
            pSnapshotName.Name = "SnapshotName";
            pSnapshotName.ParameterType = typeof(string);
            pSnapshotName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 2,
                Mandatory = true,
                ValueFromPipeline = false
            });
            pSnapshotName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("SnapshotName", pSnapshotName);

            var pSnapshot = new RuntimeDefinedParameter();
            pSnapshot.Name = "Snapshot";
            pSnapshot.ParameterType = typeof(Snapshot);
            pSnapshot.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 3,
                Mandatory = true,
                ValueFromPipeline = true
            });
            pSnapshot.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("Snapshot", pSnapshot);

            return dynamicParameters;
        }
    }
}
