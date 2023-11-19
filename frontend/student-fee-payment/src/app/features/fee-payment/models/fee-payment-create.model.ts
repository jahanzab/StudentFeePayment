import { Student } from "../../student/models/student.model"

export interface FeePaymentCreate {
    feeAmount : string
    isPaid : boolean
    paidDate: Date
    feeYear : string
    studentId: string
    remarks : string;
}
