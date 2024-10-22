﻿using BusinessLib.Bl.Contract;
using BusinessLib.Data;
using System.Xml.Linq;

namespace BusinessLib.Bl
{
    public class clsCountry : ICRUD<TbCountry>
    {
        private readonly ICRUD<TbCountry> _clsGenericRepository;

        public clsCountry(ICRUD<TbCountry> countryRepository)
        {
            _clsGenericRepository = countryRepository;
        }
        public IQueryable<TbCountry> GetAll()
        {
           
            return _clsGenericRepository.GetAll();

        }
        public TbCountry GetById(int elementId)
        {

            return _clsGenericRepository.GetById(elementId);
        }
        public int? Save(TbCountry element)
        {

            return _clsGenericRepository.Save(element);

        }
        public bool Delete(int elementId)
        {

            return _clsGenericRepository.Delete(elementId);


        }

       
    }

}
