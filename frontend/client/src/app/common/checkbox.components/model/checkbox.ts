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

    changeIsChecked() {
        this.isChecked = !this.isChecked;
    }
} 