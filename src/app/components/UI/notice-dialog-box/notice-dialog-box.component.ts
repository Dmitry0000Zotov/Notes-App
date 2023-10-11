import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import { ITag } from 'src/app/models/tag';
import { TagService } from 'src/app/services/tags/tag.service';

@Component({
  selector: 'app-notice-dialog-box',
  templateUrl: './notice-dialog-box.component.html',
  styleUrls: ['./notice-dialog-box.component.scss']
})
export class NoticeDialogBoxComponent implements OnInit{
  constructor(
    public dialogRef: MatDialogRef<NoticeDialogBoxComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private tagService: TagService
  ) {
    if(data) {
      this.isNew = false;
      this.selectedTags = data.tags;
    }
  }

  isNew: boolean = true;
  selectedDate: Date;
  tagsSubscription: Subscription;
  tagBoxPlaceholder = 'Выберите тэги';
  selectedTags: ITag[];
  availableTags: ITag[];

  noticeForm: FormGroup = new FormGroup({
    noticeId: new FormControl(this.data?.noticeId ?? null),
    title: new FormControl(this.data?.title ?? '', [Validators.required]),
    deadline: new FormControl(this.data?.deadline ?? new Date(), [Validators.required])
  });

  onSubmit(){
    this.data = {
      noticeId: this.noticeForm.value.noticeId,
      title: this.noticeForm.value.title,
      deadline: this.noticeForm.value.deadline,
      tags: this.selectedTags
    };
  
    this.dialogRef.close(this.data);
  }

  onNoClick(): void {
    this.dialogRef.close(null);
  }

  ngOnInit(): void {
    this.tagsSubscription = this.tagService.getTags().subscribe((data)=>{
      this.availableTags = data;
    });
  }
}
