using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.Data;

namespace MODMEG
{
    public static class Extensiones
    {
        public static ObjectContext GetContext(this IEntityWithRelationships entity)
        {
            
            if (entity == null)
                throw new ArgumentException("entity");

            var relationchipManager = entity.RelationshipManager;

            var relatedEnd = relationchipManager.GetAllRelatedEnds().FirstOrDefault();

            if (relatedEnd == null)
                throw new Exception("no hay relaciones encontradas");

            var query = relatedEnd.CreateSourceQuery() as ObjectQuery;

            if (query == null)
                throw new Exception("la entidad esta desconectada");

            return query.Context;
        }
        public static void AttachUpdated(this ObjectContext context, EntityObject objectDetached)
        {
            
            object currentEntityInDb = null;

            if (context.TryGetObjectByKey(objectDetached.EntityKey, out currentEntityInDb))
            {
                context.ApplyCurrentValues(objectDetached.EntityKey.EntitySetName, objectDetached);
                //context.ApplyPropertyChanges(objectDetached.EntityKey.EntitySetName, objectDetached);

                //(CDLTLL)Apply property changes to all referenced entities in context

                //context.ApplyReferencePropertyChanges((IEntityWithRelationships)objectDetached, (IEntityWithRelationships)currentEntityInDb); //Custom extensor method
                
            }

            else
            {

                throw new ObjectNotFoundException();

            }


        }
        public static void ApplyReferencePropertyChanges(this ObjectContext context, IEntityWithRelationships newEntity, IEntityWithRelationships oldEntity)
        {

            foreach (var relatedEnd in oldEntity.RelationshipManager.GetAllRelatedEnds())
            {

                var oldRef = relatedEnd as EntityReference;

                if (oldRef != null)
                {

                    // this related end is a reference not a collection

                    var newRef = newEntity.RelationshipManager.GetRelatedEnd(oldRef.RelationshipName, oldRef.TargetRoleName) as EntityReference;

                    oldRef.EntityKey = newRef.EntityKey;

                }

            }

        }
        public static void SetAllModified<T>(this T entity, ObjectContext context) where T : IEntityWithKey
        {

            var stateEntry = context.ObjectStateManager.GetObjectStateEntry(entity.EntityKey);

            var propertyNameList = stateEntry.CurrentValues.DataRecordInfo.FieldMetadata.Select(pn => pn.FieldType.Name);
            
            foreach (var propName in propertyNameList)
            {

                stateEntry.SetModifiedProperty(propName);
            }

        }
    }
}
