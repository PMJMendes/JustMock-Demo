using System.Reflection;
using System.Windows.Forms;

namespace EvalApp
{
    public class JustMockTestBase
    {
        protected object GetDotNetProperty(ContainerControl parent, string controlName, string propertyName)
        {
            var control = parent.GetType().GetField(controlName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).GetValue(parent);
            var property = control.GetType().GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            return property.GetValue(control, null);
        }

        protected void SetDotNetProperty(ContainerControl parent, string controlName, string propertyName, object value)
        {
            var control = parent.GetType().GetField(controlName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).GetValue(parent);
            var property = control.GetType().GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            property.SetValue(control, value, null);
        }

        protected void FireDotNetEvent(ContainerControl parent, string controlName, string eventName, object args)
        {
            var control = controlName == null ? parent :
                    parent.GetType().GetField(controlName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).GetValue(parent);
            var eventMethod = control.GetType().GetMethod("On" + eventName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            eventMethod.Invoke(control, new object[] { args });
        }
    }
}
