export interface TfaSetupDto {
    email: string;
    code: string;
    isTfaEnabled: boolean;
    authenticatorKey: string | null;
    formattedKey: string | null;
}