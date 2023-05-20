﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppService.DTOs;
using Data.Entities;
using Repositories.Implementaions;

namespace AppService.Implementations
{
    public class CompaniesManagementService
    {
        public List<CompanyDTO> Get()
        {
            List<CompanyDTO> companyDtos = new List<CompanyDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.CompaniesRepository.Get())
                {
                    companyDtos.Add(new CompanyDTO
                    {
                        CompanyId = item.CompanyId,
                        Name = item.Name,
                        Email = item.Email,
                        Description = item.Description
                    });
                }
            }
            return companyDtos;
        }

        public CompanyDTO GetById(int id)
        {
            CompanyDTO companyDTO = new CompanyDTO();


            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Companies companies = unitOfWork.CompaniesRepository.GetByID(id);
                if (companies != null)
                {
                    companyDTO = new CompanyDTO()
                    {
                        CompanyId = companies.CompanyId,
                        Name = companies.Name,
                        Description = companies.Description
                    };
                }
            }

            return companyDTO;
        }

        public bool Edit(CompanyDTO companyDto)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Companies company = unitOfWork.CompaniesRepository.GetByID(companyDto.CompanyId);
                    if (company != null)
                    {
                        company.Name = companyDto.Name;
                        company.Description = companyDto.Description;

                        unitOfWork.Save();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Save(CompanyDTO companyDto)
        {
            Companies company = new Companies()
            {
                CompanyId = companyDto.CompanyId,
                Name = companyDto.Name,
                Description = companyDto.Description
            };

            try
            {

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.CompaniesRepository.Insert(company);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Companies companies = unitOfWork.CompaniesRepository.GetByID(id);
                    unitOfWork.CompaniesRepository.Delete(companies);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
