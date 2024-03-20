using AutoMapper;
using BirthdayParty.Application.Repository.Common;
using BirthdayParty.Application.Service.Common;
using BirthdayParty.Domain.Models;
using BirthdayParty.Domain.Paginate;
using BirthdayParty.Domain.Payload.Request.PartyPackages;
using BirthdayParty.Domain.Payload.Request.Posts;
using BirthdayParty.Domain.Payload.Response.HostParties;
using BirthdayParty.Domain.Payload.Response.PartyPackages;
using BirthdayParty.Domain.Payload.Response.Posts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BirthdayParty.Services.Service;

public class PartyPackageService : BaseService<PartyPackageService>, IPartyPackageService
{
    private readonly IPostService _postService;

    public PartyPackageService(IUnitOfWork unitOfWork, ILogger<PartyPackageService> logger, IMapper mapper,
        IPostService postService,
        IHttpContextAccessor httpContextAccessor) : base(unitOfWork, logger, mapper, httpContextAccessor)
    {
        _postService = postService;
    }

    public async Task<string> CreatePost(string partyPackageId, CreatePostRequest request)
    {
        try
        {
            return await _postService.CreatePost(request);
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public Task<IPaginate<GetPostsResponse>> GetPosts(string partyPackageId, GetPostsRequest request)
    {
        try
        {
            var result = _unitOfWork.GetRepository<Post>().GetPagingListAsync<GetPostsResponse>(
                predicate: x => x.PartyPackageId == partyPackageId, orderBy: x => x.OrderBy(x => x.CreatedAt),
                include: null, page: request.Page, size: request.PageSize, selector: x => new GetPostsResponse
                {
                    Id = x.Id,
                    Content = x.Content,
                    Date = x.Date,
                    ImageUrl = x.ImageUrl,
                    PartyPackageId = x.PartyPackageId,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt,
                    IsDeleted = x.IsDeleted
                });
            return result;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public Task<IPaginate<GetPartyPackageResponse>> GetPartyPackages(GetPartyPackagesRequest request)
    {
        try
        {
            var result = _unitOfWork.GetRepository<PartyPackage>().GetPagingListAsync<GetPartyPackageResponse>(
                selector: x => new GetPartyPackageResponse
                (
                    x.Id,
                    x.HostPartyId,
                    x.DiscountId,
                    x.Name,
                    x.Description,
                    x.Location,
                    x.RoomSeats,
                    x.RoomUrl,
                    x.ImageUrl,
                    x.PackagePrice,
                    x.SeatPrice,
                    x.StartTime,
                    x.EndTime,
                    x.Status,
                    x.CreatedAt,
                    x.UpdatedAt,
                    x.IsDeleted,
                    x.Discount,
                    x.HostParty
                ),
                predicate: x =>
                    (request.IsDeleted.ToLower().Equals("both") || Boolean.Parse(request.IsDeleted).Equals(x.IsDeleted)) &&
                            (x.HostPartyId.Contains(request.HostPartyId) || string.IsNullOrEmpty(request.HostPartyId))
                            && x.Name.Contains(request.SearchString ?? ""),
                            //&& x.Description.Contains(request.SearchString ?? "")
                            //&& x.Location.Contains(request.SearchString ?? "")
                            //&& x.StartTime.Contains(request.SearchString ?? "")
                            //&& x.EndTime.Contains(request.SearchString ?? "")
                            //&& x.RoomSeats.ToString().Contains(request.SearchString ?? "")
                            //&& x.SeatPrice.ToString().Contains(request.SearchString ?? "")
                            //&& x.PackagePrice.ToString().Contains(request.SearchString ?? ""),
                orderBy: x => x.OrderBy(partyPackage => partyPackage.CreatedAt),
                //include: x => x.Include(partyPackage => partyPackage.Discount)!,
                page: request.Page,
                size: request.Size);

            return result;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<string> CreatePartyPackage(CreatePartyPackageRequest request)
    {
        try
        {
            var toBeAdded = new PartyPackage()
            {
                Id = Guid.NewGuid().ToString(),
                HostPartyId = request.HostPartyId,
                DiscountId = request.DiscountId,
                Name = request.Name,
                Description = request.Description,
                Location = request.Location,
                RoomSeats = request.RoomSeats,
                RoomUrl = request.RoomUrl,
                ImageUrl = request.ImageUrl,
                PackagePrice = request.PackagePrice,
                SeatPrice = request.SeatPrice,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                Status = "Inactive"
            };

            await _unitOfWork.GetRepository<PartyPackage>().InsertAsync(toBeAdded);
            await _unitOfWork.CommitAsync();

            var message = "Created Successfully";

            return message;
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public async Task<string> UpdatePartyPackage(string id, UpdatePartyPackageRequest request)
    {
        try
        {
            var toBeUpdated = await _unitOfWork.GetRepository<PartyPackage>()
                .SingleOrDefaultAsync(predicate: x => x.Id == id);

            if (toBeUpdated == null) return "Not found";

            toBeUpdated.DiscountId = request.DiscountId;
            toBeUpdated.Name = !string.IsNullOrEmpty(request.Name) ? request.Name : toBeUpdated.Name;
            toBeUpdated.Description = !string.IsNullOrEmpty(request.Description)
                ? request.Description
                : toBeUpdated.Description;
            toBeUpdated.Location = !string.IsNullOrEmpty(request.Location)
                ? request.Location
                : toBeUpdated.Location;
            toBeUpdated.RoomSeats = toBeUpdated.RoomSeats;
            toBeUpdated.RoomUrl = !string.IsNullOrEmpty(request.RoomUrl) ? request.RoomUrl : toBeUpdated.RoomUrl;
            toBeUpdated.ImageUrl = !string.IsNullOrEmpty(request.ImageUrl) ? request.ImageUrl : toBeUpdated.ImageUrl;
            toBeUpdated.PackagePrice = request.PackagePrice;
            toBeUpdated.SeatPrice = request.SeatPrice;
            toBeUpdated.StartTime = !string.IsNullOrEmpty(request.StartTime) ? request.StartTime : toBeUpdated.StartTime;
            toBeUpdated.EndTime = !string.IsNullOrEmpty(request.EndTime) ? request.EndTime : toBeUpdated.EndTime;
            toBeUpdated.Status = !string.IsNullOrEmpty(request.Status) ? request.Status : toBeUpdated.Status;
            toBeUpdated.UpdatedAt = DateTime.Now;

            _unitOfWork.GetRepository<PartyPackage>().UpdateAsync(toBeUpdated);
            await _unitOfWork.CommitAsync();

            var message = "Updated Successfully";
            return message;
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public async Task<string> DeletePartyPackage(string id)
    {
        try
        {
            var toBeDeleted = await _unitOfWork.GetRepository<PartyPackage>()
                .SingleOrDefaultAsync(predicate: x => x.Id == id);

            if (toBeDeleted == null) return "Not found";

            _unitOfWork.GetRepository<PartyPackage>().DeleteAsync(toBeDeleted);
            await _unitOfWork.CommitAsync();

            var message = "Deleted Successfully";
            return message;
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public Task<GetSinglePartyPackageResponse?> GetPartyPackage(string id)
    {
        try
        {
            var result = _unitOfWork.GetRepository<PartyPackage>().SingleOrDefaultAsync<GetSinglePartyPackageResponse>(
                predicate: x => x.Id == id, selector: x => new GetSinglePartyPackageResponse
                (
                    x.Id,
                    x.HostPartyId,
                    x.DiscountId,
                    x.Name,
                    x.Description,
                    x.Location,
                    x.RoomSeats,
                    x.RoomUrl,
                    x.ImageUrl,
                    x.PackagePrice,
                    x.SeatPrice,
                    x.StartTime,
                    x.EndTime,
                    x.Status,
                    x.CreatedAt,
                    x.UpdatedAt,
                    x.IsDeleted,
                    x.Discount,
                    x.HostParty
                ));
            return result;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}