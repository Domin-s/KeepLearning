export class Checkbox {
    id!: string;
    name!: string;
    value!: string;
    isChecked: boolean = true;

    constructor(id: string, name: string, value: string, isChecked: boolean) {
        this.id = id;
        this.name = name;
        this.value = value;
        this.isChecked = isChecked;
    }

    copy(newId?: string, newName?: string, newValue?: string, newIsChecked?: boolean){
        let id = (newId !== undefined) ? this.id : newId;
        let name = (newName !== undefined) ? this.name : newName;
        let value = (newValue !== undefined) ? this.value : newValue;
        let checked = (newIsChecked !== undefined) ? this.isChecked : newIsChecked;

        return new Checkbox(id!, name!, value!, checked!);
    }
} 