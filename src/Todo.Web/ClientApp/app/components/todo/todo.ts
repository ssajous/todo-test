export class Todo {
    todoItemId: number;
    title: string;
    isCompleted: boolean;
    isEditing: boolean;

    constructor(title: string) {
        this.title = title;
    }
}