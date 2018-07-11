
export function initializeProperties(obj: any, metadata: metadataTypes.Metadata) {
    var entityTypes = metadata.entityTypes;
    for (let entityTypeName in entityTypes) {
        var entitySetName = entityTypes[entityTypeName].entitySetName;
        var navProp = (function (entityTypeName: string) {
            var _entityTypeName = entityTypeName;
            var result = function () {
                return this.getPropertyValue(_entityTypeName);
            };
            return result;
        })(entityTypeName);

        Object.defineProperty(obj, entitySetName, {
            get: navProp,
            enumerable: false,
            configurable: true
        });

    }
}