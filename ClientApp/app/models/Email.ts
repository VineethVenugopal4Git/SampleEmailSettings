export interface IEmail {
    id: number;
    salutation: string;
    subject: string;
    description: string;
    signature: string;
}

export class Email implements IEmail {
    id: number;
    salutation: string;
    subject: string;
    description: string;
    signature: string;
}