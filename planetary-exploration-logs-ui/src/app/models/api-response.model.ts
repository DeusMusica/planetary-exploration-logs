export interface ApiResponse<T> {
    success: boolean;
    message: string;
    statusCode: number;
    data: T; // Generic type to wrap the data
  }
  