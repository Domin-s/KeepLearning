export class Select {
    id!: string;
    name!: string;
    options!: string[];

    constructor(id: string, name: string, options: string[]) {
        this.id = id;
        this.name = name;
        this.options = options;
    }
} 