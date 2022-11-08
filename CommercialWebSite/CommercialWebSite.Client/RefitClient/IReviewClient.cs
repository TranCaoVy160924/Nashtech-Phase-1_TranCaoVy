using CommercialWebSite.ShareDTO.Business;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace CommercialWebSite.Client.RefitClient
{
    public interface IReviewClient
    {
        [Post("/Review")]
        Task<IActionResult> PostReviewAsync([Body] ProductReviewModel reviewModel,
            [Header("Authorization")] string jwtToken);
    }
}
