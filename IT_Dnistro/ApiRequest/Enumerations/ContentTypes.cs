using System.ComponentModel.DataAnnotations;

namespace ApiRequest.Enumerations
{
    public enum ContentTypes
    {
        [Display(Name = @"application/json")]
        ApplicationJson,
        [Display(Name = @"application/xml")]
        Xml,
        [Display(Name = @"texp/plain")]
        Text,
        [Display(Name = @"application/octet-stream")]
        Binary,
        [Display(Name = @"image/jpeg")]
        Jpeg
    }
}