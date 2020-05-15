using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace TestBD01.Droid.Helper
{
    public class WriteExternalStorage
    {
        public async Task<string> WriteStorage()
        {
			try
			{
                if (!await PermissionUtils.GetPermission<Permissions.StorageWrite>())
                {
                    return string.Empty;
                }
                return string.Empty;
            }
			catch (Exception ex)
			{
                return ex.Message;
            }
        }
    }
}