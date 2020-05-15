using Android.OS;
using System.Threading.Tasks;
using Xamarin.Essentials;
using static Xamarin.Essentials.Permissions;

namespace TestBD01.Droid.Helper
{
    class PermissionUtils
    {
        public static async Task<bool> GetPermission<TPermission>() where TPermission : BasePermission, new()
        {
            // Aquí aun en lollipop 5.0 no me da permiso de escritura
            if ((int)Build.VERSION.SdkInt < 23)  
            {  
                return true;  
            }

            var hasPermission = await Permissions.CheckStatusAsync<TPermission>();
            if (hasPermission == PermissionStatus.Granted)
                return true;
            else if (hasPermission == PermissionStatus.Disabled)
                return false;

            var result = await Permissions.RequestAsync<TPermission>();
            if (result != PermissionStatus.Granted)
                return false;

            return true;
        }
    }
}