using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;

namespace WindowsWorkflowVisualDebugger
{
    public static class ActivityHelper
    {
        public static object GetValueOfWorkflowVariable(WorkflowDataContext dataContext, string valueName)
        {
            object value = null;

            PropertyDescriptorCollection propertyDescriptorCollection = dataContext.GetProperties();

            foreach(PropertyDescriptor propertyDesc in propertyDescriptorCollection)
            {
                if(propertyDesc.Name == valueName)
                {
                    value = propertyDesc.GetValue(dataContext);
                    break;
                }
            }

            return value;
        }

    }
}
