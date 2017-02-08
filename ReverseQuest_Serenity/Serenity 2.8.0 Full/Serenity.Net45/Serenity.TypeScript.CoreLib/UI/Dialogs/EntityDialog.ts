﻿declare namespace Serenity {

    class EntityDialog<TItem, TOptions> extends TemplatedDialog<TOptions> {
        constructor(options?: TOptions);
        protected saveAndCloseButton: JQuery;
        protected applyChangesButton: JQuery;
        protected deleteButton: JQuery;
        protected undeleteButton: JQuery;
        protected cloneButton: JQuery;
        protected entity: TItem;
        protected entityId: any;
        protected toolbar: Toolbar;
        dialogOpen(): void;
        loadByIdAndOpenDialog(id: any): void;
        protected afterLoadEntity(): void;
        protected beforeLoadEntity(entity: TItem): void;
        protected deleteHandler(options: ServiceOptions<DeleteResponse>, callback: (response: DeleteResponse) => void): void;
        protected doDelete(callback: (response: DeleteResponse) => void): void;
        protected getCloningEntity(): TItem;
        protected getDeleteOptions(callback: (response: DeleteResponse) => void): ServiceOptions<DeleteResponse>;
        protected getEntityIdField(): string;
        protected getEntityIsActiveField(): string;
        protected getEntityNameField(): string;
        protected getEntityNameFieldValue(): any;
        protected getEntitySingular(): string;
        protected getEntityTitle(): string;
        protected getEntityType(): string;
        protected getFormKey(): string;
        protected getLanguages(): string[][];
        protected getLoadByIdOptions(id: any, callback: (response: RetrieveResponse<TItem>) => void): ServiceOptions<RetrieveResponse<TItem>>;
        protected getLoadByIdRequest(id: any): RetrieveRequest;
        protected getLocalTextPrefix(): string;
        protected getPropertyGridOptions(): PropertyGridOptions;
        protected getPropertyGridOptionsAsync(): PromiseLike<PropertyGridOptions>;
        protected getPropertyItems(): PropertyItem[];
        protected getPropertyItemsAsync(): PromiseLike<PropertyItem[]>;
        protected getSaveEntity(): TItem;
        protected getSaveOptions(callback: (response: SaveResponse) => void): ServiceOptions<SaveResponse>;
        protected getSaveRequest(): SaveRequest<TItem>;
        protected getService(): string;
        protected getToolbarButtons(): ToolButton[];
        protected getUndeleteOptions(callback: (response: UndeleteResponse) => void): ServiceOptions<UndeleteResponse>;
        protected get_entity(): TItem;
        protected get_entityId(): any;
        protected isCloneMode(): boolean;
        protected isDeleted(): boolean;
        protected isEditMode(): boolean;
        protected isLocalizationMode(): boolean;
        protected isNew(): boolean;
        protected isNewOrDeleted(): boolean;
        protected initToolbar(): void;
        protected initializeAsync(): PromiseLike<void>;
        public load(entityOrId: any, done: () => void, fail: () => void): void;
        public loadById(id: any): void;
        public loadByIdAndOpenDialog(id: any): void;
        protected loadByIdHandler(options: ServiceOptions<RetrieveResponse<TItem>>, callback: (response: RetrieveResponse<TItem>) => void, fail: () => void): void;
        public loadEntity(entity: any): void;
        public loadEntityAndOpenDialog(entity: any): void;
        public loadNewAndOpenDialog(): void;
        public loadResponse(response: RetrieveResponse<TItem>): void;
        protected onDeleteSuccess(response: DeleteResponse): void;
        protected onLoadingData(data: RetrieveResponse<TItem>): void;
        protected onSaveSuccess(response: SaveResponse): void;
        protected reloadById(): void;
        protected save(callback: (response: SaveResponse) => void): void;
        protected saveHandler(options: ServiceOptions<SaveResponse>, callback: (response: SaveResponse) => void): void;
        protected save_submitHandler(callback: (response: SaveResponse) => void): void;
        protected set_entity(entity: any): void;
        protected set_entityId(id: any): void;
        protected showSaveSuccessMessage(response: SaveResponse): void;;
        protected undelete(): void;
        protected undeleteHandler(options: ServiceOptions<UndeleteResponse>, callback: (response: UndeleteResponse) => void): void;
        protected updateInterface(): void;
        protected updateTitle(): void;
        protected validateBeforeSave(): boolean;
        protected propertyGrid: Serenity.PropertyGrid;
    }
}