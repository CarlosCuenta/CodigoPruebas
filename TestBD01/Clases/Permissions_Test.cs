using System;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace TestBD01.Clases
{
    class Permissions_Test
    {
        
        public async  void ObtenerPermiso()
        {
            
            var status = PermissionStatus.Unknown;
            status = await Permissions.CheckStatusAsync<Permissions.Battery>();
        }
        
    }
}
