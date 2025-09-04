using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterWeatherApi.Domain.Models.Image;

public class ImageResponseModel
{
    public ImageResponseModel(string url)
    {
        ImageUrl = url;
    }
    public string ImageUrl { get; set; }
}
