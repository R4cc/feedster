﻿using Feedster.DAL.Data;
using Feedster.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Feedster.DAL.Repositories;

public class FeedRepository
{
    private readonly ApplicationDbContext _db;
    public FeedRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<List<Feed>> GetAll()
    {
        return await _db.Feeds.ToListAsync();
    }    
    
    public async Task Create(Feed feed)
    {
        await _db.Feeds.AddAsync(feed);
    }    
    
    public async Task UpdateRange(List<Feed> feeds)
    {
        _db.Feeds.UpdateRange(feeds);
    }
    
    public async Task<Feed> Get(int id)
    {
        return await _db.Feeds.FirstOrDefaultAsync(f => f.FeedId == id);
    }
}