import { Student } from "../../student/models/student.model"

export interface FeePayment {
    id : string
    feeAmount : number
    isPaid : boolean
    paidDate: Date
    feeYear : string
    student: Student
}
