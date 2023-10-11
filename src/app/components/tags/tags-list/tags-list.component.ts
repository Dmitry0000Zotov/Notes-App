import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import { ITag } from 'src/app/models/tag';
import { TagService } from 'src/app/services/tags/tag.service';
import { DeleteDialogBoxComponent } from '../../UI/delete-dialog-box/delete-dialog-box.component';

@Component({
  selector: 'app-tags-list',
  templateUrl: './tags-list.component.html',
  styleUrls: ['./tags-list.component.scss']
})
export class TagsListComponent implements OnInit{
  tags: ITag[];
  createdTag: ITag;
  tagsSubscription: Subscription;

  constructor(private tagService: TagService, public dialog: MatDialog) {}

  tagForm: FormGroup = new FormGroup({
    title: new FormControl('', [Validators.required, Validators.pattern(/^[a-zA-Zа-яА-ЯёЁ]+$/)])
  })

  onSubmit() {
    if(this.tagForm.valid) {
      this.createdTag = { tagId: '', title: this.tagForm.value.title };
      this.tagService.createTag(this.createdTag).subscribe((data) => this.tags.push(data));
      this.tagForm.reset();
    }
  }

  deleteTag(tagId: string) {
    this.tagService.deleteTag(tagId).subscribe(()=> {
      const foundItem = this.tags.find(item => item.tagId === tagId);
      if (foundItem) {
        const idx = this.tags.findIndex(item => item.tagId === tagId);
        this.tags.splice(idx, 1);
      }
    });
  }

  openDeleteDialog(tagId: string, type: string) {
    let deleteDialogConfig = new MatDialogConfig();
    deleteDialogConfig.disableClose = true;
    deleteDialogConfig.data = { id: tagId, type: type };

    const deleteDialogRef = this.dialog.open(DeleteDialogBoxComponent, deleteDialogConfig);
    deleteDialogRef.afterClosed().subscribe((data) => {
        if(data) this.deleteTag(data);
    });
  }

  ngOnInit(): void {
    this.tagsSubscription = this.tagService.getTags().subscribe((data)=>{
      this.tags = data;
    });  
  }
}
