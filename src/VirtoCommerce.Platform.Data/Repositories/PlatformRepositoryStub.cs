using System;
using System.Linq;
using System.Threading.Tasks;
using VirtoCommerce.Platform.Core.Domain;
using VirtoCommerce.Platform.Data.Model;

namespace VirtoCommerce.Platform.Data.Repositories
{
    public class PlatformRepositoryStub : IPlatformRepository
    {
        public IQueryable<AssetEntryEntity> AssetEntries => Array.Empty<AssetEntryEntity>().AsQueryable();

        public IQueryable<SettingEntity> Settings => Array.Empty<SettingEntity>().AsQueryable();

        public IQueryable<DynamicPropertyEntity> DynamicProperties => Array.Empty<DynamicPropertyEntity>().AsQueryable();

        public IQueryable<DynamicPropertyDictionaryItemEntity> DynamicPropertyDictionaryItems => Array.Empty<DynamicPropertyDictionaryItemEntity>().AsQueryable();

        public IQueryable<OperationLogEntity> OperationLogs => Array.Empty<OperationLogEntity>().AsQueryable();

        public IUnitOfWork UnitOfWork => new UnitOfWorkStub();

        public void Add<T>(T item) where T : class
        {
            //Nothing todo
        }

        public void Attach<T>(T item) where T : class
        {
            //Nothing todo
        }

        public void Dispose()
        {
            //Nothing todo
        }

        public Task<AssetEntryEntity[]> GetAssetsByIdsAsync(string[] ids)
        {
            return Task.FromResult(Array.Empty<AssetEntryEntity>());
        }

        public Task<DynamicPropertyEntity[]> GetDynamicPropertiesByIdsAsync(string[] ids)
        {
            return Task.FromResult(Array.Empty<DynamicPropertyEntity>());
        }

        public Task<DynamicPropertyEntity[]> GetDynamicPropertiesForTypesAsync(string[] objectTypes)
        {
            return Task.FromResult(Array.Empty<DynamicPropertyEntity>());
        }

        public Task<DynamicPropertyDictionaryItemEntity[]> GetDynamicPropertyDictionaryItemByIdsAsync(string[] ids)
        {
            return Task.FromResult(Array.Empty<DynamicPropertyDictionaryItemEntity>());
        }

        public Task<DynamicPropertyEntity[]> GetObjectDynamicPropertiesAsync(string[] objectTypes)
        {
            return Task.FromResult(Array.Empty<DynamicPropertyEntity>());
        }

        public Task<SettingEntity[]> GetObjectSettingsByNamesAsync(string[] names, string objectType, string objectId)
        {
            return Task.FromResult(Array.Empty<SettingEntity>());
        }

        public Task<OperationLogEntity[]> GetOperationLogsByIdsAsync(string[] ids)
        {
            return Task.FromResult(Array.Empty<OperationLogEntity>());
        }

        public void Remove<T>(T item) where T : class
        {
           //Nothing todo
        }

        public void Update<T>(T item) where T : class
        {
            //Nothing todo
        }
    }   
}
