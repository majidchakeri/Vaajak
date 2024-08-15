﻿using Microsoft.AspNetCore.Identity;
using Vaajak.Application.Dto.Account;
using Vaajak.Application.Dto.Primitives;
using Vaajak.Domain.Entities;
using Vaajak.Domain.Repositories.Account;
using X.PagedList;
using X.PagedList.Extensions;

namespace Vaajak.Application.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        //public async Task<IPagedList<AccountDto>> GetAllAsync(PaginationRequestDTO paginationRequestDTO)
        //{
        //    try
        //    {
        //        var accounts = await _accountRepository.GetAllAsync(paginationRequestDTO);
        //        var accountDto = accounts.Select(account => new AccountDto
        //        {
        //            Id = account.Id,
        //            Username = account.Username,
        //            Email = account.Email,
        //            FirstName = account.FirstName,
        //            LastName = account.LastName,
        //        });

        //        var paginatedAccounts = accountDto.ToPagedList(paginationRequestDTO.PageNumber, paginationRequestDTO.PageSize);
        //        return paginatedAccounts;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);

        //    }


        //}

        public async Task<SignupDto> SignupAsync(SignupDto signupDto)
        {
            try
            {
                var account = new User
                {
                    UserName = signupDto.Username,
                    Email = signupDto.Email,
                    FirstName = signupDto.FirstName,
                    LastName = signupDto.LastName,
                    PasswordHash = signupDto.Password,
                };

                var result = await _accountRepository.SignupAsync(account, signupDto.Password);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
