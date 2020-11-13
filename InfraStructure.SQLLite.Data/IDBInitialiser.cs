using System;

namespace InfraStructure.SQLLite.Data
{
    public interface IDBInitialiser
    {
        void SeedDB(FotoFactoryContext ctx);
    }

}
