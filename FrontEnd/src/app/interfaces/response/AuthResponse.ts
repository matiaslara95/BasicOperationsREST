export interface AuthResponse {
    isAuthSuccessful: boolean;
    isTfaEnabled: boolean;
    errorMessage: string;
    token: string;
}