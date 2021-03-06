import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ResourceService } from 'src/app/project-info/resources-table-for-project/resources-table/resource.service';
import { ResourceCategoriesService } from 'src/app/project-info/resources-table-for-project/resources-table/resource-categories.service';
import { ResourceCategory } from '../../resource-models/resource-category';
import * as Constants  from '../../../shared/constants/resources-table';
import { ResourceCreateService } from '../../resource-create/resource-create.service';
import { DialogService } from 'src/app/shared/services/dialog.service';
import { ResourceCreateComponent } from '../../resource-create/resource-create.component';

@Component({
  selector: 'app-general-resources-table',
  templateUrl: './general-resources-table.component.html',
  styleUrls: ['./general-resources-table.component.less'],
  encapsulation: ViewEncapsulation.None
})
export class GeneralResourcesTableComponent implements OnInit {

  resourcesCategories: ResourceCategory[];
  showCategories = false;
  dataSource;
  constructor(public resourceService: ResourceService,
              public resourceCategoriesService: ResourceCategoriesService,
              public resourceCreateService : ResourceCreateService,
              public dialogService : DialogService
  ) { }

  async ngOnInit() {
    this.resourcesCategories = await this.resourceCategoriesService
      .getResourceCategories(Constants.ResourcesTableConstants.WITH_ASSIGNED_RESOURCES);
    this.showCategories = true;
  }

  addResource(){
    this.resourceCreateService.initializeForm();
    this.dialogService.openFormDialog(ResourceCreateComponent);
  }
}
