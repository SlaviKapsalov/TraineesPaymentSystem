using System;

namespace TraineesPaymentSystem.Common
{
    public static class ControllerHelper
    {
        public static string GetControllerName(string controller)
        {
            if (string.IsNullOrWhiteSpace(controller))
            {
                throw new ArgumentNullException(nameof(controller));
            }

            var name = controller.Replace("Controller", "");

            return name;
        }
    }
}
