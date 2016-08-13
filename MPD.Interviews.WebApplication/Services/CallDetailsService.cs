using System;
using System.Collections.Generic;
using AutoMapper;
using MPD.Interviews.Domain;
using MPD.Interviews.Interfaces.Logging;
using MPD.Interviews.Interfaces.Repositories;
using MPD.Interviews.WebApplication.Services.Interfaces;
using MPD.Interviews.WebApplication.ViewModels;

namespace MPD.Interviews.WebApplication.Services
{
    public class CallDetailsService : ICallDetailsService
    {
        private readonly IRepository<CallDetails> _repository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly ICallDetailsSearchRepository _callDetailsSearchRepository;

        public CallDetailsService(IRepository<CallDetails> repository, ILogger logger, IMapper mapper, ICallDetailsSearchRepository callDetailsSearchRepository)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _callDetailsSearchRepository = callDetailsSearchRepository;
        }

        public bool AddCallDetailRecord(CallDetailViewModel model)
        {
            try
            {
                var callDetails = _mapper.Map<CallDetails>(model);
                return _repository.Save(callDetails);
            }
            catch (Exception ex)
            {
                _logger.Error($"Error saving CallDetailViewModel. Error: {ex.Message}", ex);
                return false;
            }
        }

        public IList<CallDetailViewModel> GetAllCalls()
        {
            try
            {
                var callDetails = _repository.GetAll();

                var viewModel = _mapper.Map<IList<CallDetailViewModel>>(callDetails);
                
                return viewModel;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error retrieving all call details. Error: {ex.Message}", ex);
                throw;
            }
        }

        public IList<CallDetailViewModel> GetCallsBySearch(CallSearchTermsViewModel searchTerms)
        {
            try
            {
                var newSearchTerms = new CallSearchTerms(searchTerms.UserId, searchTerms.CustomLabel, searchTerms.StartDate, searchTerms.EndDate, searchTerms.PhoneNumber);
                var callsBySearch = _callDetailsSearchRepository.CallDetailsSearch(newSearchTerms);
                var viewModel = _mapper.Map<IList<CallDetailViewModel>>(callsBySearch);

                return viewModel;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error retrieving calls by search. Error: {ex.Message}", ex);
                throw;
            }
        }
    }
}