export class Select {
    id!: string;
    name!: string;
    description!: string;
    options!: any[];

    constructor(id: string, name: string, description: string, options: any[]) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.options = options;
    }
} 