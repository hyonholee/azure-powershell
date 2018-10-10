// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.Compute.Common;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VmssVMDataDisk")]
    [OutputType(typeof(PSVirtualMachineScaleSet))]
    public class RemoveAzureRmVmssVMDataDiskCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = HelpMessages.VMProfile)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachineScaleSetVM VirtualMachineScaleSetVM { get; set; }

        [Parameter(
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = false,
            HelpMessage = HelpMessages.VMDataDiskName)]
        [ValidateNotNullOrEmpty]
        public int Lun { get; set; }

        public override void ExecuteCmdlet()
        {
            if (this.ShouldProcess("DataDisk", VerbsCommon.Remove))
            {
                var storageProfile = this.VirtualMachineScaleSetVM.StorageProfile;

                if (storageProfile != null && storageProfile.DataDisks != null)
                {
                    var disks = storageProfile.DataDisks.ToList();

                    disks.RemoveAll(d => d.Lun == this.Lun);

                    if (disks.Count == 0)
                    {
                        disks.Clear();
                    }

                    storageProfile.DataDisks = disks;
                }

                this.VirtualMachineScaleSetVM.StorageProfile = storageProfile;

                WriteObject(this.VirtualMachineScaleSetVM);
            }
        }
    }
}
