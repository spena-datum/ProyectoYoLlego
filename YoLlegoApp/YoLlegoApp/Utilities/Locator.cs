using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YoLlegoApp.Models;
using Xamarin.Essentials;

namespace YoLlegoApp.Utilities
{
    class Locator
    {
        public async Task<Response> getLocatorData()
        {
            Models.Location loc = new Models.Location();
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    return new Response
                    {
                        IsSucess = true,
                        Result = location
                    };
                    
                }
                return new Response
                {
                    IsSucess = false,
                    Message = $"Location is null"
                };
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                return new Response
                {
                    IsSucess = false,
                    Message = $"El dispositivo no es compatible para conocer la ubicación - {fnsEx.Message}"
                };
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                return new Response
                {
                    IsSucess = false,
                    Message = $"Ubicación no habilitada - {fneEx.Message}"
                };
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                return new Response
                {
                    IsSucess = false,
                    Message = $"No se tienen los permisos necesarios - {pEx.Message}"
                };
            }
            catch (Exception ex)
            {
                // Unable to get location
                return new Response
                {
                    IsSucess = false,
                    Message = $"No se pudo obtener la ubicación - {ex.Message}"
                };
            }
        }
        
    }
}
