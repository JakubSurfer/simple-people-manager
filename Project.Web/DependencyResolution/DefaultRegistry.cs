// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Data.Entity;
using Project.Infrastructure.Database;
using StructureMap.Web;
using Project.Domain.Entities;
using Project.Infrastructure.Configuration;
using Project.Infrastructure.Mapping;
using Project.Infrastructure.Store;
using Project.Web.Models;

namespace Project.Web.DependencyResolution {
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
	
    public class DefaultRegistry : Registry {

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                });

            For<DbContext>().HybridHttpOrThreadLocalScoped().Use<DbContext>();
            For<PersonDbContext>().HybridHttpOrThreadLocalScoped().Use<PersonDbContext>();
            For<IDbRepository<Person>>().Use<PersonRepository>();
            For<IFlatMapper>().Use<FlatMapper>();   
            For<IXmlConfiguration>().Use<XmlConfiguration>();
            For<IDataStoreService<Person>>().Use<DataStoreService<Person>>();
            For<IDataStore<Person>>().Add<PersonXmlDataStore>();
            For<IDataStore<Person>>().Add<DbDataStore>();
            For<IDataStore<Person>>().Add<FileDataStore>();
            For<IEnumerable<IDataStore<Person>>>().Use(x => x.GetAllInstances<IDataStore<Person>>());         
        }
    }
}