import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Subscription } from 'rxjs';
import { ITag } from 'src/app/models/tag';
import { TagService } from 'src/app/services/tags/tag.service';

@Component({
  selector: 'app-dialog-box',
  templateUrl: './dialog-box.component.html',
  styleUrls: ['./dialog-box.component.scss']
})
export class DialogBoxComponent implements OnInit{
  constructor(
    public dialogRef: MatDialogRef<DialogBoxComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private tagService: TagService
  ) { 
    if(data) {
      this.isNew = false;
      this.selectedTags = data.tags; 
    }
  }

  isNew: boolean = true;
  tagsSubscription: Subscription;
  tagBoxPlaceholder = 'Выберите тэги';
  selectedTags: ITag[];
  availableTags: ITag[];

  noteForm: FormGroup = new FormGroup({
    noteId: new FormControl(this.data?.noteId ?? null),
    title: new FormControl(this.data?.title ?? '', [Validators.required]),
    details: new FormControl(this.data?.details ?? '', [Validators.required]),
    dateNote: new FormControl(this.data?.dateNote ?? new Date())
  });
  
  onSubmit(){
    this.data = {
      noteId: this.noteForm.value.noteId,
      title: this.noteForm.value.title,
      details: this.noteForm.value.details,
      dateNote: this.noteForm.value.dateNote,
      tags: this.selectedTags
    };
  
    this.dialogRef.close(this.data);
  }

  onNoClick(): void {
    this.dialogRef.close(null);
  }


  ngOnInit(): void{
    this.tagsSubscription = this.tagService.getTags().subscribe((data)=>{
      this.availableTags = data;
    });
  }
}
