export class Select {
    id!: string;
    name!: string;
    description!: string;
    options!: any[];

    constructor(id: string, name: string, title: string, options: any[]) {
        this.id = id;
        this.name = name;
        this.description = title;
        this.options = options;
    }
} 