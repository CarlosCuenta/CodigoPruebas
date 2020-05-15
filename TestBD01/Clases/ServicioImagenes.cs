using Plugin.Media;
using Plugin.Media.Abstractions;
using System.Threading.Tasks;

namespace TestBD01.Clases
{
    public static class ServicioImagenes
    {
        public static async Task<MediaFile> SeleccionarImagen()
        {
            await CrossMedia.Current.Initialize();
            var file = await CrossMedia.Current.PickPhotoAsync();
            return file;

        }
    }
}
