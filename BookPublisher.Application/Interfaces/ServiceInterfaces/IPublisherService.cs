﻿using BookPublisher.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookPublisher.Application.Dto;

namespace BookPublisher.Application.Interfaces.ServiceInterfaces
{
    public interface IPublisherService
    {
        Task<IEnumerable<Publisher>> GetAllPublishers();
        Task<Publisher> GetPublisherById(int id);
        Task<Publisher> CreatePublisher(Publisher publisher);
        Task<Publisher> UpdatePublisher(Publisher publisher);
        Task<Publisher> DeletePublisher(int id);
        Task<IEnumerable<Book>> GetBooksByPublisher(int publisherId);
    }
}