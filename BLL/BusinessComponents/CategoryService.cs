using BLL.BusinessEntities;
using BLL.Mappers;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.BusinessComponents
{
    public class CategoryService
    {
        private readonly FoodCategoryRepository _repository;

        public CategoryService()
        {
            _repository = new FoodCategoryRepository();
        }

        // Lấy tất cả
        public List<FoodCategoryDTO> GetAll()
        {
            var entities = _repository.GetAll();
            List<FoodCategoryDTO> dtos = new List<FoodCategoryDTO>();
            foreach (var entity in entities)
            {
                var dto = CategoryMapper.ToDTO(entity);
                dtos.Add(dto);
            }
            return dtos;
        }

        // Lấy theo ID
        public FoodCategoryDTO GetById(int id)
        {
            var entity = _repository.GetById(id);
            return entity != null ? CategoryMapper.ToDTO(entity) : null;
        }

        // Thêm mới
        public void Add(FoodCategoryDTO dto)
        {
            var entity = CategoryMapper.ToEntity(dto);
            _repository.Add(entity);
        }

        // Cập nhật
        public void Update(FoodCategoryDTO dto)
        {
            var entity = CategoryMapper.ToEntity(dto);
            _repository.Update(entity);
        }

        // Xóa
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        // Tìm theo tên
        public List<FoodCategoryDTO> GetFoodCategoriesByName(string name)
        {
            var foodCategories = _repository.GetFoodCategoriesByName(name);
            List<FoodCategoryDTO> dtos = new List<FoodCategoryDTO>();
            foreach (var category in foodCategories)
            {
                FoodCategoryDTO dto = CategoryMapper.ToDTO(category);
                dtos.Add(dto);
            }
            return dtos;
        }
    }
}
