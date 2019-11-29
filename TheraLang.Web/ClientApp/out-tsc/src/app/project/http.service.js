import { __decorate } from "tslib";
import { Injectable } from '@angular/core';
import { baseUrl } from '../shared/api-endpoint.constants';
let HttpService = class HttpService {
    constructor(http) {
        this.http = http;
        this.url = baseUrl;
    }
    getAllProjects() {
        return this.http.get(this.url + 'project');
    }
    getProjectInfo(id) {
        return this.http.get(this.url + 'project' + '/' + id);
    }
    getAllProjectParticipants() {
        return this.http.get(this.url + 'projectParticipants');
    }
    changeParticipationStatus(requestId, requestStatus) {
        return this.http.put(this.url + 'projectParticipants' + '/' + requestId, requestStatus);
    }
    getResourcesByCategoryId(categoryId, pageNumber, recordsPerPage) {
        return this.http.get(this.url + 'resource/all/' + categoryId + '/' + pageNumber
            + '/' + recordsPerPage);
    }
    getResourceCategories(withAssignedResources) {
        return this.http.get(this.url + 'resource/categories' + '/' + withAssignedResources);
    }
    getResourcesCountByCategoryId(categoryId) {
        return this.http.get(this.url + 'resource/count' + '/' + categoryId);
    }
    getAllResourcesById(projectId) {
        return this.http.get(this.url + 'project' + '/' + projectId + '/' + 'resources');
    }
    getPiranhaPageById(pageId) {
        return this.http.get(this.url + 'page/' + pageId);
    }
    createProject(project) {
        return this.http.post(this.url + 'project' + '/' + 'create', project, { observe: 'response' });
    }
    updateProject(project) {
        return this.http.put(this.url + '/' + project.id, project, { observe: 'response' });
    }
    getAllProjectTypes() {
        return this.http.get(this.url + '/' + 'projectTypes');
    }
};
HttpService = __decorate([
    Injectable()
], HttpService);
export { HttpService };
//# sourceMappingURL=http.service.js.map