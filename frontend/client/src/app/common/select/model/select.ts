export class Select {
    id!: string;
    name!: string;
    description!: string;
    options!: string[];

    constructor(id: string, name: string, title: string, options: string[]) {
        this.id = id;
        this.name = name;
        this.description = title;
        this.options = options;
    }
} 