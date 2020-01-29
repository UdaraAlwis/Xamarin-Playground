using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Location = Xamarin.Essentials.Location;

namespace XFHybridWebViewAdvDemo
{
    public class DeviceFeaturesHelper
    {
        public async Task<string> TakePhoto(ContentPage pageContext)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await pageContext.DisplayAlert("No Camera", ":( No camera available.", "OK");
                return null;
            }

            await CheckForCameraAndGalleryPermission();

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "TestPhotoFolder",
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.Medium,
                MaxWidthHeight = 1000,
            });

            if (file == null)
                return null;

            // Convert bytes to base64 content
            var imageAsBytesBase64 = Convert.ToBase64String(ConvertFileToByteArray(file));

            return imageAsBytesBase64;
        }

        public async Task<string> SelectPhoto(ContentPage pageContext)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await pageContext.DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return null;
            }

            await CheckForCameraAndGalleryPermission();

            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
            });

            if (file == null)
                return null;

            // Convert bytes to base64 content
            var imageAsBytesBase64 = Convert.ToBase64String(ConvertFileToByteArray(file));

            return imageAsBytesBase64;
        }

        private byte[] ConvertFileToByteArray(MediaFile imageFile)
        {
            // Convert Image to bytes
            byte[] imageAsBytes;
            using (var memoryStream = new MemoryStream())
            {
                imageFile.GetStream().CopyTo(memoryStream);
                imageFile.Dispose();
                imageAsBytes = memoryStream.ToArray();
            }

            return imageAsBytes;
        }

        private async Task<bool> CheckForCameraAndGalleryPermission() 
        {
            List<Permission> permissionList = new List<Permission>{ Permission.Camera, Permission.Storage, Permission.Photos };

            List<PermissionStatus> permissionStatuses = new List<PermissionStatus>();
            foreach (var permission in permissionList)
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(permission);
                permissionStatuses.Add(status);
            }

            var requiresRequesst = permissionStatuses.Any(x => x != PermissionStatus.Granted);

            if (requiresRequesst)
            {
                var permissionRequestResult = await CrossPermissions.Current.RequestPermissionsAsync(permissionList.ToArray());
            }

            return true;
        }

        public async Task<string> GetDeviceData() 
        {
            // Device Model (SMG-950U, iPhone10,6)
            var device = DeviceInfo.Model;

            // Manufacturer (Samsung)
            var manufacturer = DeviceInfo.Manufacturer;

            // Device Name (Motz's iPhone)
            var deviceName = DeviceInfo.Name;

            // Operating System Version Number (7.0)
            var version = DeviceInfo.VersionString;

            // Platform (Android)
            var platform = DeviceInfo.Platform;

            // Idiom (Phone)
            var idiom = DeviceInfo.Idiom;

            // Device Type (Physical)
            var deviceType = DeviceInfo.DeviceType;

            return $"{nameof(DeviceInfo.Model)}: {device}<br />" +
                $"{nameof(DeviceInfo.Manufacturer)}: {manufacturer}<br />" + 
                $"{nameof(DeviceInfo.Name)}: {deviceName}<br />" +
                $"{nameof(DeviceInfo.VersionString)}: {version}<br />" +
                $"{nameof(DeviceInfo.Platform)}: {platform}<br />" +
                $"{nameof(DeviceInfo.Idiom)}: {idiom}<br />" +
                $"{nameof(DeviceInfo.DeviceType)}: {deviceType}";
        }

        public async Task<string> GetGpsLocation()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.High);
            var location = await Geolocation.GetLocationAsync(request);

            if (location != null)
            {
                return $"{nameof(Location.Latitude)}: {location.Latitude}<br />" +
                       $"{nameof(Location.Longitude)}: {location.Longitude}<br />" +
                       $"{nameof(Location.Altitude)}: { location.Altitude ?? 0.00 }";
            }

            return null;
        }
    }
}
