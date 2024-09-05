export enum ReturnType {
  Success = 0,
  NotFound = 1,
  InternalError = 2
}

export class Response<T> {
  returnType: ReturnType = ReturnType.Success;
  message: string = "";
  returnedValue: T[] = [];
}
