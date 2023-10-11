export interface INote {
    noteId: string
    title: string 
    details: string
    dateCreation: Date
    dateEdit: Date
    dateNote: Date
    tags: Array<any> 
}