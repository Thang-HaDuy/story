import Typography from '@mui/material/Typography';

const TextComing = () => {
    return (
        <Typography
            sx={{
                position: 'absolute',
                bottom: '0',
                display: 'flex',
                justifyContent: 'center',
                width: '100%',
                backgroundColor: '#d43939',
                color: '#fff',
                fontSize: '13px',
                fontWeight: '300',
                paddingY: '4px',
                zIndex: 5,
            }}
        >
            SẮP CHIẾU
        </Typography>
    );
};

export default TextComing;
